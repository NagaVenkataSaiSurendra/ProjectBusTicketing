import React, { useState } from 'react';
import './DashBoard.css';
import { BrowserRouter as Router, Link, Routes, Route } from 'react-router-dom';
import Menu from './Menu';
import AdminMenu from './AdminMenu';

function DashBoard() {
  const [isSecondaryNavActive, setIsSecondaryNavActive] = useState(false);

  const handleSecondaryNavToggle = () => {
    setIsSecondaryNavActive(!isSecondaryNavActive);
  };

  return (
    
      <div>
        <div className="top-bar">
          {/* First Navigation Bar */}
          <div className={`nav-bar first-nav-bar ${isSecondaryNavActive ? 'hidden' : ''}`}>
            <label className="nav-link" onClick={handleSecondaryNavToggle}>User Menu</label>
            <label className="nav-link" onClick={handleSecondaryNavToggle}>Admin Menu</label>
          </div>

          {/* Second Navigation Bar */}
          <div className={`nav-bar second-nav-bar ${isSecondaryNavActive ? '' : 'hidden'}`}>
            <Link to="/Menu" className="nav-link">User Menu</Link>
            <Link to="/AdminMenu" className="nav-link">Admin Menu</Link>
          </div>
        </div>

        
      </div>
    
  );
}

export default DashBoard;
