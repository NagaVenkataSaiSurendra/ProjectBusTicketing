import React, { useState } from 'react';

function UpdateUser() {
    //const [userId, setUserId] = useState(''); // Assuming you have a userId
    const roles=["user" ,"Admin"];
    const [userName, setUserName] = useState('');
    const [password, setPassword] = useState('');
    const [role, setRole] = useState('');
    const [email, setEmail] = useState('');
    const [phone, setPhone] = useState('');
    const [city, setCity] = useState('');
    const [pincode, setPincode] = useState('');
    const [errorMessage, setErrorMessage] = useState('');

    const updateUser = async () => {
        try {
            const response = await fetch(`http://localhost:5041/api/Customer/UserProfiles/${userName}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    userName: userName,
                    role: role,
                    password: password,
                    email: email,
                    phone: phone,
                    city: city,
                    pincode: pincode,
                }),
            });

            if (!response.ok) {
                const errorData = await response.json();
                throw new Error(`HTTP error! Status: ${response.status}, Message: ${errorData.message || 'Unknown error'}`);
            }

            // Handle success if needed
            console.log('Update successful');
        } catch (error) {
            console.error('Fetch error:', error.message);
            setErrorMessage(`Error updating user details. ${error.message}`);
        }
    };
    return (
        <form className="registerForm">
             <label className="form-control">Username</label>
            <input type="text" className="form-control" value={userName}
                    onChange={(e)=>{setUserName(e.target.value)}}/>
           
            <label className="form-control">Password</label>
            <input type="password" className="form-control" value={password}
                    onChange={(e)=>{setPassword(e.target.value)}}/>
            <label className="form-control">Email</label>
            <input type="text" className="form-control" value={email}
                    onChange={(e)=>{setEmail(e.target.value)}}/>
             <label className="form-control">Phone Number</label>
            <input type="text" className="form-control" value={phone}
                    onChange={(e)=>{setPhone(e.target.value)}}/>
              <label className="form-control">City</label>
             <input type="text" className="form-control" value={city}
                            onChange={(e)=>{setCity(e.target.value)}}/>
            <label className="form-control">Pincode</label>
            <input type="text" className="form-control" value={pincode}
                    onChange={(e)=>{setPincode(e.target.value)}}/>
            <label className="form-control">Role</label>
             <select className="form-select" onChange={(e)=>{setRole(e.target.value)}}>
                <option value="select">Select Role</option>
                {roles.map((r)=>
                    <option value={r} key={r}>{r}</option>
                )}
            </select>
           
            <br/>
            <button className="btn btn-primary button" onClick={updateUser}>
                Update Details
            </button>
            <button className="btn btn-danger button" onClick={() => alert('Cancelled')}>
                Cancel
            </button>
        </form>
    );
}

export default UpdateUser;
