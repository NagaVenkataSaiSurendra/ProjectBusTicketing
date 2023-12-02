import { useState } from "react";

function BookingList(){
    const [bookingList,setBookingList]=useState([]);
    var getBookings=()=>{
        fetch('http://localhost:5041/api/booking',{
        method:"GET",
        headers:{
            'Accept':'application/json',
            'Content-Type':'application/json'
        }
        }).then( async (data)=>{
            var myData = await data.json();
            await console.log(myData);
            await setBookingList(myData);
        }
    ).catch((e)=>{
        console.log(e)
    })
}
var checkBookings = bookingList.length>0?true:false;
return(
    <div>
        <h1 className="alert alert-success">Bookings</h1>
        <button className="btn btn-success" onClick={getBookings}>Get All Bookings</button>
        <hr/>
        {checkBookings? 
            <div >
                {bookingList.map((b)=>
                    <div key={b.id} className="alert alert-primary">
                       Bus Type : {b.type}
                        <br/>
                        Cost : {b.cost}
                        <br/>
                        Booked Seats : {b.bookedSeats}
                        <br/>
                       Available Seats: {b.availableSeats}
                        <br/>
                        Start : {b.start}
                        <br/>
                        ENd :{b.end}
                </div>)}
            </div>
            :
            <div>No Bookings available yet</div>
            }
    </div>
);

    
}
export default BookingList;