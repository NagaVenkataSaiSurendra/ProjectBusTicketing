import { useState } from 'react';
import './App.css';
import Seat from './Components/Seat'
import BusListing from './Components/BusListing';

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

  return (
    <div>
    <div className="container">
        <div className="row">
          <div class="col">
           <BusListing buses={buses} onAddClick={bookSeat}/>
          </div>
          <div className="col">
           <Seat bookSeat={seat} />
          </div>
        </div>
      </div>
    </div>
  );
}

export default App;