import React, { useState } from 'react';
import axios from 'axios';
import './UpdateUser.css';

function UpdateUser() {
  const [userName, setUserName] = useState('');
  const [email, setEmail] = useState('');
  const [phone, setPhone] = useState('');
  const [city, setCity] = useState('');
  const [pincode, setPincode] = useState('');
  const [errorMessage, setErrorMessage] = useState('');
  const [startError, setStartError] = useState('');
  const [searchError, setSearchError] = useState('');
  const [searchResults, setSearchResults] = useState([]);
  const [searchPerformed, setSearchPerformed] = useState(false);

  const checkUpdateUser = () => {
    if (userName === '') {
      setStartError('User name cannot be empty');
      return false;
    }

    return true;
  };

  const handleSearch = (event) => {
    event.preventDefault();
    setStartError('');
    setSearchError('');

    const isValidData = checkUpdateUser();

    if (!isValidData) {
      setSearchError('Please check your data');
      return;
    }

    axios
      .put('http://localhost:5041/api/Customer/UserProfiles', {
        userName: userName,
        email: email,
        phone: phone,
        city: city,
        pincode: pincode,
      })
      .then((response) => {
        console.log(response.data);
        alert("Updated Successfully!!");
        setSearchResults(response.data);
        setSearchPerformed(true);
      })
      .catch((err) => {
        console.error(err);
        setSearchError('Error updating the user details. Please try again.');
      });
  };

  return (
    <form className="update">
      <label className="form-control">Username</label>
      <input
        type="text"
        className="form-control"
        value={userName}
        onChange={(e) => {
          setUserName(e.target.value);
        }}
      />

      <label className="form-control">Email</label>
      <input
        type="text"
        className="form-control"
        value={email}
        onChange={(e) => {
          setEmail(e.target.value);
        }}
      />
      <label className="form-control">Phone Number</label>
      <input
        type="text"
        className="form-control"
        value={phone}
        onChange={(e) => {
          setPhone(e.target.value);
        }}
      />
      <label className="form-control">City</label>
      <input
        type="text"
        className="form-control"
        value={city}
        onChange={(e) => {
          setCity(e.target.value);
        }}
      />
      <label className="form-control">Pincode</label>
      <input
        type="text"
        className="form-control"
        value={pincode}
        onChange={(e) => {
          setPincode(e.target.value);
        }}
      />

      <br />
      {searchError && <p className="error-message">{searchError}</p>}

      <button className="btn btn-primary button" onClick={handleSearch}>
        Update Details
      </button>
      <button className="btn btn-danger button" onClick={() => alert('Cancelled')}>
        Cancel
      </button>
    </form>
  );
}

export default UpdateUser;
