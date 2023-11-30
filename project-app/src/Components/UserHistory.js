import { useState } from "react";
import axios from "axios";

function UserHistory(){
    const [id,setId]=useState("");
    const [idError, setIdError] = useState("");
    const [searchError,setSearchError]=useState("");
    const [searchResults,setSearchResults]=useState("");
    const [searchPerformed, setSearchPerformed] = useState(false);

    const userData=()=>{
        if(id===""){
        setIdError("Please enter your Id!!");
        return false;
            
        }
        return true;
    }
    const handleSearch = (event) => {
        event.preventDefault();
        setIdError("");
        setSearchError("");
    
        const isValidData = userData();
    
        if (!isValidData) {
          setSearchError("Please check your data");
          return;
        }
    
        axios
          .post("http://localhost:5041/api/Customer/UserBookingHistory", {
            id:id,
          })
          .then((response) => {
            console.log(response.data);
            setSearchResults(response.data);
            setSearchPerformed("true");

          })
          .catch((err) => {
            console.error(err);
            setSearchError("Error searching user. Please try again.");
          });
      };
      
      return(
        <div>
        <form>
        <label >UserId</label>
          <input
            type="text"
            className="form-control"
            value={id}
            onChange={(e) => setId(e.target.value)}
          />
           {idError && <p className="error-message">{idError}</p>}

          <button className="btn btn-primary button" onClick={handleSearch}>
            History
          </button>
        </form>
        {searchPerformed && (
        <div>
        <h2>Booking History</h2>
        <table className="table">
          <thead>
            <tr>
            <th>S.No</th>
              <th>BookingId</th>
              <th>UserId</th>
              <th>BusId</th>
              <th>Date</th>
              <th>TotalCost</th>
              <th>SelectedSeats</th>
            </tr>
          </thead>
          <tbody>
          {searchResults.map((user, index) => (
              <tr key={user.id}>
                <td>{index + 1}</td>
                <td>{user.bookingId}</td>
                <td>{user.userId}</td>
                <td>{user.busId}</td>
                <td>{user.date}</td>
                <td>{user.totalFare}</td>
                <td>{user.selectedSeats.join(',')}</td>
              </tr>
             ))}
          </tbody>
        </table>
      </div>
        )}
  </div>

    );
    
}
export default UserHistory;