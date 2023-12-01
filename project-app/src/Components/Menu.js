import { Link } from "react-router-dom";
import Buses from './Buses';
import './Menu.css';

function Menu(){
    return (
//<div className="container">
<nav className="navbar navbar-expand-lg navbar-light bg-light">
  
  <div className="collapse navbar-collapse" id="navbarNav">
    <ul className="navbar-nav">
      <li className="nav-item active">
        <Link className="nav-link" to="/" >Register/Login</Link>
      </li>
      <li className="nav-item">
        <Link className="nav-link" to="/Buses" >Buses</Link>
      </li>
      <li className="nav-item">
        <Link className="nav-link" to="/SearchBus" >Search</Link>
      </li>
      <li className="nav-item">
        <Link className="nav-link" to="/updateUser" >UpdateUserDetails</Link>
      </li>
      <li className="nav-item">
        <Link className="nav-link" to="/busSeatSelection" >BusSeatSelection</Link>
      </li>
      <li className="nav-item">
        <Link className="nav-link" to="/UserHistory" >UserHistory</Link>
      </li>
     <li className="nav-item">
      <Link className="nav-link" to="/Users">Users</Link>
     </li>
     <li className="nav-item">
      <Link className="nav-link" to="/BookingList">Bookings</Link>
     </li>

    </ul>
  </div>
</nav>
//</div>
    );
}

export default Menu;
