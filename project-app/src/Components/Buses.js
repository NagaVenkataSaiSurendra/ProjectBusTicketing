import { useState } from "react";
function Buses(){
    const [busList,setBusList]=useState([])
    var getbuses = ()=>{
        fetch('http://localhost:5041/api/bus',{
            method:'GET',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            }
        }).then(
            async (data)=>{
                var myData = await data.json();
                await console.log(myData);
                await setBusList(myData);
            }
        ).catch((e)=>{
            console.log(e)
        })
    }
    var checkBuses = busList.length>0?true:false;
return(
    <div>
        <h1 className="alert alert-success">Buses</h1>
        <button className="btn btn-success" onClick={getbuses}>Get All Buses</button>
        <hr/>
        {checkBuses? 
            <div >
                {busList.map((bus)=>
                    <div key={bus.id} className="alert alert-primary">
                        Bus Type : {bus.type}
                        <br/>
                        Start : {bus.start}
                        <br/>
                        End : {bus.end}
                        <br/>
                        Bus Capacity: {bus.availableSeats}
                        <br/>
                        Ticket Price : {bus.cost}
                </div>)}
            </div>
            :
            <div>No Buses available yet</div>
            }
    </div>
);
}
export default Buses; 
 