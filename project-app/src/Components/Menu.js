import { Link } from "react-router-dom";
import './Menu.css';
import home from './home.png';
import bus from './bus.jpg';

function Menu() {
  const role =localStorage.getItem("role");
  return (
    <div className="container">
      <nav className="navbar navbar-expand-lg navbar-light bg-light">
        <div className="collapse navbar-collapse" id="navbarNav">
        {role==="Admin" &&

         <ul><li className="nav-item">
           <Link className="nav-link" to="/Buses">
             <img src={bus} alt="bus" className="icon" />Buses
           </Link>
         </li>
         <li className="nav-item">
           <Link className="nav-link" to="/updateUser">UpdateUserDetails</Link>
         </li>
         <li className="nav-item">
           <Link className="nav-link" to="/Users">Users</Link>
         </li>
         <li className="nav-item">
           <Link className="nav-link" to="/BookingList">Bookings</Link>
         </li>
         <li className="nav-item">
           <Link className="nav-link" to="/addBus">AddBus</Link>
         </li>
         <li className="nav-item">
           <Link className="nav-link" to="/UpdateBus">UpdateBus</Link>
         </li>
          <li className="nav-item">
           <Link className="nav-link" to="/Logout">Logout</Link>
         </li>
         
       </ul>}
       {role==="User"  &&
          <ul className="navbar-nav">
            <li className="nav-item">
              <Link className="nav-link" to="/RedBus">
                <img src={home} alt="home" className="icon" />
                Home
              </Link>
            </li>
            <li className="nav-item">
              <Link className="nav-link" to="/UserHistory">UserHistory</Link>
            </li>
            <li className="nav-item">
              <Link className="nav-link" to="/CancelledBookings">Cancelled bookings</Link>
            </li>
             <li className="nav-item">
              <Link className="nav-link" to="/Logout">Logout</Link>
            </li>
            
          </ul>}
        </div>
        <div className="ml-auto">
          <Link className="nav-link" to="/UserLogin">Register/Login</Link>
        </div> <div className="collapse navbar-collapse" id="navbarNav">
       
        </div>
      </nav>
    </div>
  );
}

export default Menu;

 