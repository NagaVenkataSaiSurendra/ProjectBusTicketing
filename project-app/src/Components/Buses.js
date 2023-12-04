import { useState } from "react";
function Buses(){
    const [busList,setBusList]=useState([])
    const [searchPerformed,setSearchPerformed]=useState(false);
    var getbuses = ()=>{
        fetch('http://localhost:5041/api/bus',{
            method:'GET',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json',
               'Authorization': 'Bearer ' + localStorage.getItem("token")
            }
        }).then(
            async (data)=>{
                var myData = await data.json();
                await console.log(myData);
                await setBusList(myData);
                await setSearchPerformed(true);
            }
        ).catch((e)=>{
            console.log(e)
        })
    }
    var checkBuses = busList.length>0?true:false;
return(
    <div>
        <center><h1 className="alert alert-success"><center>Buses</center></h1></center>
        <center><button className="btn btn-success" onClick={getbuses}>Get All Buses</button></center>
        {searchPerformed && (
        <div>
          <center>
            <table className="table">
              <thead>
                <tr>
                  <th>S.No</th>
                  <th>BusId</th>
                  <th>Type</th>
                  <th>Cost</th>
                  <th>Available Seats</th>
                  <th>Booked Seats</th>
                  <th>Start</th>
                  <th>End</th>
                </tr>
              </thead>
              <tbody>
                {busList.map((bus, index) => (
                  <tr key={bus.busId}>
                    <td>{index + 1}</td>
                    <td>{bus.id}</td>
                    <td>{bus.type}</td>
                    <td>{bus.cost}</td>
                    <td>{bus.availableSeats}</td>
                    <td>{bus.bookedSeats}</td>
                    <td>{bus.start}</td>
                    <td>{bus.end}</td>
                  </tr>
                ))}
              </tbody>
            </table>
          </center>
        </div>
      )}

    </div>
);
}
export default Buses; 
 