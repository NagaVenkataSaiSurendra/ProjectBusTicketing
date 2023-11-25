import logo from './logo.svg';
import './App.css';
import AddBus from './Components/AddBus';
import Buses from './Components/Buses';
import RegisterUser from './Components/RegisterUser';
import UserLogin from './Components/UserLogin';


function App() {
  return (
     <div className="container text-center">
  <div className="row">
    <div className="col">
      <RegisterUser/> 
    </div>
    <div className="col">
      <UserLogin/>
    </div>
  </div>
  
</div>
  );
}

export default App;
