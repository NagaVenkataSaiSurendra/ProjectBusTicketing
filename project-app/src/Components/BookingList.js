import { useState } from "react";
import './BookingList.css';
function BookingList(){
    const [bookingList,setBookingList]=useState([]);
    const [searchPerformed,setSearchPerformed]=useState(false);
    var getBookings=(event)=>{
      event.preventDefault();
        fetch('http://localhost:5041/api/booking',{
        method:"GET",
        headers:{
            'Accept':'application/json',
            'Content-Type':'application/json',
            'Authorization': 'Bearer ' + localStorage.getItem("token")
        }
        }).then( async (data)=>{
            var myData = await data.json();
            await console.log(myData);
            await setBookingList(myData);
            await setSearchPerformed("true");
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
        {searchPerformed && (
        <div>
        <h2>Booking History</h2>
        <table className="table">
          <thead>
            <tr>
            <th>S.No</th>
              <th>BookingId</th>
              <th>UserName</th>
              <th>BusId</th>
              <th>Date</th>
              <th>TotalCost</th>
              <th>SelectedSeats</th>
            </tr>
          </thead>
          <tbody>
          {bookingList.map((booking, index) => (
              <tr key={booking.userName}>
                <td>{index + 1}</td>
                <td>{booking.bookingId}</td>
                <td>{booking.userName}</td>
                <td>{booking.busId}</td>
                <td>{booking.date}</td>
                <td>{booking.totalFare}</td>
                <td>{booking.selectedSeats.join(',')}</td>
              </tr>
             ))}
          </tbody>
        </table>
      </div>
        )}
  </div>
);

    
}
export default BookingList;