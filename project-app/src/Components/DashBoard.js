import React from 'react';
import { Link } from 'react-router-dom';
import { styled } from '@mui/system';
import Box from '@mui/material/Box';

// Define a styled component using the styled utility
const NavBar = styled(Box)({
  backgroundColor: '#2196f3', // Set your desired background color
  padding: '16px', // Adjust padding as needed
  display: 'flex',
  justifyContent: 'space-around',
});

const NavLink = styled(Link)({
  color: 'white', // Set your desired text color
  textDecoration: 'none',
  fontSize: '16px', // Set your desired font size
});

function DashBoard() {
  return (
    <Box>
      <NavBar>
        {/* Display the navigation links with Mui styling */}
        <NavLink to="/Menu">User Menu</NavLink>
        <NavLink to="/AdminMenu">Admin Menu</NavLink>
      </NavBar>
    </Box>
  );
}

export default DashBoard;
