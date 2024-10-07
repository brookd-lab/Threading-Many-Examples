using Quartz;
using Quartz.Impl;
using NLog;

await JobScheduler();
while (true) ;

async static Task JobScheduler()
{

    var config = new NLog.Config.LoggingConfiguration();

    //var logfile = new NLog.Targets.FileTarget("logfile") { FileName = @"c:\temp\log\log.log", ArchiveEvery = NLog.Targets.FileArchivePeriod.Day, MaxArchiveFiles = 3, ArchiveFileName = "archive/log.{###}.log", ArchiveNumbering = NLog.Targets.ArchiveNumberingMode.Rolling, Layout = "${longdate}|${level:uppercase=true}|${processname}|${threadid}|${message}" };
    //var logfile = new NLog.Targets.FileTarget("logfile") { FileName = @"c:\temp\log\log.log", ArchiveEvery = NLog.Targets.FileArchivePeriod.Day, MaxArchiveFiles = 3, ArchiveFileName = "archive/log.{###}.log", ArchiveNumbering = NLog.Targets.ArchiveNumberingMode.Rolling, Layout = "${message}" };
    
    //**** Log to file by date

    var logfile = new NLog.Targets.FileTarget("logfile")
    {
        FileName = @"C:\temp\log\${date:format=yyyy-MM-dd:cached=true}\${date:format=HH.mm.ss:cached=true}.log",
        Layout = "${message}"
    };

    config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);
    NLog.LogManager.Configuration = config;
    var logger = NLog.LogManager.GetCurrentClassLogger();
    
    //var logger = NLog.LogManager.GetCurrentClassLogger();
    try
    {
        // construct a scheduler factory
        ISchedulerFactory schedFact = new StdSchedulerFactory();

        // get a scheduler
        var sched = await schedFact.GetScheduler();

        await sched.Start();

        IJobDetail job = JobBuilder.Create<LoggingJob>()
            .WithIdentity("myJob", "group1")
            .Build();

        ITrigger trigger = TriggerBuilder.Create()
            .WithDailyTimeIntervalSchedule
            (s =>
                s.WithIntervalInSeconds(5)
                    .OnEveryDay()
                    .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(16, 15))
            )
            .Build();

        //ITrigger trigger = TriggerBuilder.Create()
        //       .WithIdentity("myJob", "group1")
        //       .WithSimpleSchedule(x => x.WithIntervalInSeconds(5).RepeatForever())
        //        .Build();

        await sched.ScheduleJob(job, trigger);
    }
    catch (ArgumentException e)
    {
        logger.Error(e);
    }
}




public class LoggingJob : IJob
{
    Task IJob.Execute(IJobExecutionContext context)
    {
        //Console.WriteLine("hello world");
        
        NLog.LogManager.GetLogger("LoggingJob").Info(
                string.Format("\r\nLogging job : {0} {1}, and proceeding to log",
                    DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString()));
        return Task.CompletedTask;
    }
}
