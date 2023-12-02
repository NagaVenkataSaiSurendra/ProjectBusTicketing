import { useState } from "react";
import axios from "axios";
import './UserHistory.css';

function UserHistory(){
    const [userName,setUserName]=useState("");
    const [userNameError, setUserNameError] = useState("");
    const [searchError,setSearchError]=useState("");
    const [searchResults,setSearchResults]=useState("");
    const [searchPerformed, setSearchPerformed] = useState(false);

    const userData=()=>{
        if(userName===""){
        setUserNameError("Please enter your USerName!!");
        return false;
            
        }
        return true;
    }
    const handleSearch = (event) => {
        event.preventDefault();
        setUserNameError("");
        setSearchError("");
    
        const isValidData = userData();
    
        if (!isValidData) {
          setSearchError("Please check your data");
          return;
        }
    
        axios
          .post("http://localhost:5041/api/Customer/UserBookingHistory", {
            userName:userName,
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
        <div className="history">
        <form>
        <label >UserName</label>
          <input
            type="text"
            className="form-control"
            value={userName}
            onChange={(e) => setUserName(e.target.value)}
          />
           {userNameError && <p className="error-message">{userNameError}</p>}

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
              <th>UserName</th>
              <th>BusId</th>
              <th>Date</th>
              <th>TotalCost</th>
              <th>SelectedSeats</th>
            </tr>
          </thead>
          <tbody>
          {searchResults.map((user, index) => (
              <tr key={user.userName}>
                <td>{index + 1}</td>
                <td>{user.bookingId}</td>
                <td>{user.userName}</td>
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