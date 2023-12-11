import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import styled from 'styled-components';
import AppBar from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import Button from '@mui/material/Button';
import home from './home.png';

const Container = styled.div`
  flex-grow: 1;
`;

const NavItem = styled(Typography)`
  margin-right: 16px; /* Adjust as needed */
`;

const Icon = styled.img`
  margin-right: 8px; /* Adjust as needed */
`;

const MlAuto = styled.div`
  margin-left: auto;
`;

function Menu() {
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  const handleLogin = () => {
    // Perform login logic
    setIsLoggedIn(true);
  };

  const handleLogout = () => {
    // Perform logout logic
    setIsLoggedIn(false);
  };

  return (
    <Container>
      <AppBar position="static">
        <Toolbar>
          <NavItem variant="h6">
            <Link to="/RedBus" className="nav-link">
              <Icon src={home} alt="home" />
              Home
            </Link>
          </NavItem>

          <NavItem variant="h6">
            <Link to="/UserHistory" className="nav-link">
              UserHistory
            </Link>
          </NavItem>

          <NavItem variant="h6">
            <Link to="/CancelledBookings" className="nav-link">
              Cancelled bookings
            </Link>
          </NavItem>

          <NavItem variant="h6">
            <Link to="/Logout" className="nav-link">
              Logout
            </Link>
          </NavItem>

          <MlAuto>
            {!isLoggedIn && (
              <Button color="inherit" onClick={handleLogin} component={Link} to="/UserLogin">
                Register/Login
              </Button>
            )}

            {isLoggedIn && (
              <Button color="inherit" onClick={handleLogout}>
                Logout
              </Button>
            )}
          </MlAuto>
        </Toolbar>
      </AppBar>
    </Container>
  );
}

export default Menu;
