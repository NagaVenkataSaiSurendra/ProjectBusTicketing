import React from 'react';
import { Link } from 'react-router-dom';
import './DashBoard.css';
import Menu from './Menu';
import AdminMenu from './AdminMenu';

function DashBoard() {
  return (
    <div>
      <div className="nav-bar">
        {/* Display the navigation links without conditional rendering */}
        <div className="nav-bar ">
          <Link to="/Menu" className="nav-link">
            User Menu
          </Link>
          <Link to="/AdminMenu" className="nav-link">
            Admin Menu
          </Link>
        </div>
      </div>
    </div>
  );
}

export default DashBoard;
