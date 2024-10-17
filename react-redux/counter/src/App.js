import "./App.css";
import { useSelector, useDispatch } from "react-redux";
import {actions} from './store/index';

function App() {
  const counter = useSelector((state) => state.counter);
  const dispatch = useDispatch();

  const increment = (amount=1) => {
    dispatch(actions.increment(amount));
  };
  const decrement = (amount=1) => {
    dispatch(actions.decrement(amount));
  };
  const addBy = (amount=10) => {
    dispatch(actions.addBy(amount));
  };

  return (
    <div>
      <h1>Counter App</h1>
      <h2>{counter}</h2>
      <button onClick={() => increment()}>Increment</button>
      <button onClick={() => decrement()}>Decrement</button>
      <button onClick={() => addBy(50)}>Add By 10</button>
    </div>
  );
}

export default App;
