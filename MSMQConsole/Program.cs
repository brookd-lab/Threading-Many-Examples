using MSMQ.Messaging;

//From Windows Service, use this code
MessageQueue messageQueue = null;
if (MessageQueue.Exists(@".\Private$\SomeTestName"))
{
    messageQueue = new MessageQueue(@".\Private$\SomeTestName");
    messageQueue.Label = "Testing Queue";
    var count = messageQueue.GetAllMessages().Count() > 0;
    //messageQueue.Send("Second ever Message is sent to MSMQ", "Title");
    while (messageQueue.GetAllMessages().Count() > 0)
    {
        messageQueue.Formatter = new XmlMessageFormatter(new String[] { "System.String,mscorlib" }); Console.Write(messageQueue.Receive().Body);
    }
}
else
{
    // Create the Queue
    MessageQueue.Create(@".\Private$\SomeTestName");
    messageQueue = new MessageQueue(@".\Private$\SomeTestName");
    messageQueue.Label = "Newly Created Queue";
}
messageQueue.Send("First ever Message is sent to MSMQ", "Title");
messageQueue.Send("Second ever Message is sent to MSMQ", "Title");
messageQueue.Send("Third ever Message is sent to MSMQ", "Title");

messageQueue.Formatter = new XmlMessageFormatter(new String[] { "System.String,mscorlib" });Console.Write(messageQueue.Receive().Body);

Console.WriteLine();