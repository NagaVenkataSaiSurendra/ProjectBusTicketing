import React from 'react';

const Logout = () => {
  const handleLogout = () => {
    // Clear user data from local storage
    localStorage.removeItem('thisUserName');
    localStorage.removeItem('token');

    // Redirect the user to the login page if needed
    // You can use the useHistory hook if you are using React Router
    // import { useHistory } from 'react-router-dom';
    // const history = useHistory();
    // history.push('/login');

    // Alternatively, you can reload the entire page to reset the application state
    window.location.reload();
    alert("Logout Succesfully!!");
  };

  return (
    <button className="btn btn-warning button" onClick={handleLogout}>
      Logout
    </button>
  );
};

export default Logout;
