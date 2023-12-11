import { Link } from "react-router-dom";
import './Menu.css';
import home from './home.png';
import bus from './bus.jpg';

function Menu() {
  return (
    <div className="container">
      <nav className="navbar navbar-expand-lg navbar-light bg-light">
        <div className="collapse navbar-collapse" id="navbarNav">
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
              <Link className="nav-link" to="/Cancellation">Booking Cancellation</Link>
            </li>
           
            
             <li className="nav-item">
              <Link className="nav-link" to="/Logout">Logout</Link>
            </li>
            
          </ul>
        </div>
        <div className="ml-auto">
          <Link className="nav-link" to="/UserLogin">Register/Login</Link>
        </div>
      </nav>
    </div>
  );
}

export default Menu;
