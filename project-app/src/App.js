import { useState } from 'react';
import './App.css';
import Seat from './Components/Seat'
import BusListing from './Components/BusListing';
import Menu from './Components/Menu';
import RegisterUser from './Components/RegisterUser';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import DisplaySeat from './Components/DisplaySeat';
import Products from './Components/Buses';
import Protected from './Protected';


function App() {
  var buses =[
    {
       "id":101,
       "type":"A/c",
       "seatNo":10,
       "cost":500
   },
   {
      "id":102,
      "type":"Non-A/c",
      "seatNo":2,
      "cost":800
   },
   {
      "id":103,
      "type":"Super-Deluxe",
      "seatNo":8,
      "cost":700
   }
]
var [seat,setSeat]=useState([]);
var bookSeat=(bNo)=>{
  setSeat([...seat,bNo])
  console.log(seat)
  
}

var [IsLoggedIn,setLoggedIn]=useState(false);
var changeState=()=>{
  var token = localStorage.getItem("token");
  if(token){
    setLoggedIn(true);
  }
}

  return (
    <div>
      <BrowserRouter>
        <Menu/>
        <Routes>
          <Route path='/' element={<RegisterUser/>}/>
          <Route path="buses" element={<BusListing buses={buses}/>}/>
          
          <Route path="seat" element={<Seat/>}/>
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;