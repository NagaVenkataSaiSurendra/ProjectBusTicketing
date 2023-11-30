import { useState } from 'react';
import './App.css';
import BusSeatSelection from './Components/BusSeatSelection';
import SearchBus from './Components/SearchBus';
import UpdateUser from './Components/UpdateUser';
import Seat from './Components/Seat'
import Menu from './Components/Menu';
import RegisterUser from './Components/RegisterUser';
import UserLogin from './Components/UserLogin';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import DisplaySeat from './Components/DisplaySeat';
import Buses from './Components/Buses';
import Protected from './Protected';
import UserHistory from './Components/UserHistory';
import Users from './Components/Users';


function App() {

// var [IsLoggedIn,setLoggedIn]=useState(false);
// var changeState=()=>{
//   var token = localStorage.getItem("token");
//   if(token){
//     setLoggedIn(true);
//   }
// }

  return (
  
   // <div  className="container">
       <BrowserRouter>
       
         <Menu/>
        <Routes>
          <Route path='/' element={<RegisterUser/>}/>
          <Route path="/UserLogin" element={<UserLogin/>}/>
          <Route path="Buses" element={<Buses/>}/>
          <Route path="SearchBus" element ={<SearchBus/>}/>
          <Route path="Seat" element={<Seat/>}/>
          <Route path="BusSeatSelection" element={<BusSeatSelection/>}/>
          <Route path="UpdateUser" element={<UpdateUser/>}/>
          <Route path="UserHistory" element={<UserHistory/>}/>
          <Route path="Users" element={<Users/>}/>
        </Routes>
      </BrowserRouter>  
      
   // </div>
  );
}

export default App;