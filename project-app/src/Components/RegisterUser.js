import { useState } from "react";
import './RegisterUser.css';
import axios from "axios";

function RegisterUser(){
    const [username,setUsername] = useState("");
    const [email,setEmail] = useState("");
    const [phone,setPhone] = useState("");
    const [city,setCity] = useState("");
    const [pincode,setPincode] = useState("");
    const [password,setPassword] = useState("");
    const [repassword,setrePassword] = useState("");
    const [role,setRole] = useState("");
    const [usernameError,setUsernameError]=useState("");
    const [emailError,setEmailError]=useState("");
    const [phoneError,setPhoneError]=useState("");
    const [cityError,setCityError]=useState("");
    const [pincodeError,setPincodeError]=useState("");
    const [passwordError,setPasswordError]=useState("");
    const [repasswordError,setRePasswordError]=useState("");
    var checkUSerData = ()=>{
        if(username=='')
        {
            setUsernameError("Username cannot be empty");
            return false;
        }
        if(email=='')
        {
            setEmailError("Email cannot be empty");
            return false;
        }
        if(phone=='')
        {
            setPhoneError("Phone Number cannot be empty");
            return false;
        }
        if(city=='')
        {
            setCityError("City cannot be empty");
            return false;
        }
        if(pincode=='')
        {
            setPincodeError("Pincode cannot be empty");
            return false;
        }
           
        if(password==''){
            setPasswordError("Password cannot be Empty");
            return false;
        }
        if(password!=repassword){
            setRePasswordError("Password and Repassword should be same");
            return false;
        }

        
      return true;
    }
    const signUp = (event)=>{
        event.preventDefault();
        var checkData = checkUSerData();
        if(checkData==false)
        {
            alert('please check your data')
            return;
        }
        
        axios.post("http://localhost:5041/api/Customer",{
            username: username,
            role:	"User",
            password:password,
            email:email,
            city:city,
            phone:phone,
            pincode:pincode
    })
        .then((userData)=>{
            console.log(userData);
            alert("Registration Successfull!!")

        })
        .catch((err)=>{
            console.log(err)
        })
    }
    
    return(
        <form className="registerForm">
           <div className="label-input-container">
  <label htmlFor="username">Username</label>
  <input
    type="text"
    id="username"
    className="form-control"
    value={username}
    onChange={(e) => setUsername(e.target.value)}
  />
</div>
           <label >{usernameError}</label>
            <label className="label-input-container">Email</label>
            <input type="email" className="form-control" value={email}
                    onChange={(e)=>{setEmail(e.target.value)}}/>
            <label >{emailError}</label>
             <label className="label-input-container">Phone</label>
            <input type="text" className="form-control" value={phone}
                    onChange={(e)=>{setPhone(e.target.value)}}/>
            <label >{phoneError}</label>
             <label className="label-input-container">City</label>
            <input type="text" className="form-control" value={city}
                    onChange={(e)=>{setCity(e.target.value)}}/>
            <label >{cityError}</label>
             <label className="label-input-container">Pincode</label>
            <input type="text" className="form-control" value={pincode}
                    onChange={(e)=>{setPincode(e.target.value)}}/>
            <label >{pincodeError}</label>
            <label className="label-input-container">Password</label>
            <input type="password" className="form-control" value={password}
                    onChange={(e)=>{setPassword(e.target.value)}}/>
            <label>{passwordError}</label>
            <label className="label-input-container">Re-Type Password</label>
            <input type="text" className="form-control" value={repassword}
                    onChange={(e)=>{setrePassword(e.target.value)}}/>
            <label>{repasswordError}</label>
            
            <button className="btn btn-primary button" onClick={signUp}>Sign Up</button>
            
            <button className="btn btn-danger button">Cancel</button>
    
        </form>
    );
}

export default RegisterUser;
         