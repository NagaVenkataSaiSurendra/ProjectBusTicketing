import { useState } from "react";
import axios from "axios";
import './UserLogin.css'
function UserLogin(){
    const roles =["User"];
    const [username,setUsername] = useState("");
    const [password,setPassword] = useState("");
    var [role,setRole] = useState("");
    const [thisUserName, setThisUserName] = useState(null);
    const [thisToken, setThisToken] = useState(null);
    const [thisCost, setThisCost] = useState(null);
    const [thisEmail,setThisEmail]=useState(null);
    var [usernameError,setUsernameError]=useState("");
    var checkUSerData = ()=>{
        if(username=='')
        {
            setUsernameError("Username cannot be empty");
            return false;
        }
           
        if(password=='')
            return false;
        if(username=="Admin-Vinay" || username=="Admin-Naga"){
                role="Admin";
            }
        else{
            role="User";
         }
   
             
        return true;
    }
    const logIn = (event)=>{
        event.preventDefault();
        var checkData = checkUSerData();
        if(checkData==false)
        {
            alert('please check yor data')
            return;
        }
        
        axios.post("http://localhost:5041/api/Customer/Login",{
            username: username,
            role:	role,
            password:password
    })
    
    .then((userData)=>{
        console.log(userData);
        alert("Successfully Logged In!!")
        localStorage.setItem('thisUserName', username);
        var token =userData.data.token;
        localStorage.setItem("token",token); 
        var cost=userData.data.cost;
        localStorage.setItem("cost",cost);
        var email=userData.data.email;
        localStorage.setItem("email",email);

        
        
    })
    .catch((err)=>{
        console.log(err)
    })
}
return(
            <form className="loginForm">

            <label className="form-control">Username</label>
            <input type="text" className="form-control" value={username}
                    onChange={(e)=>{setUsername(e.target.value)}}/>
                <label>{usernameError}</label>
                
            <label className="form-control">Password</label>
            <input type="password" className="form-control" value={password}
                    onChange={(e)=>{setPassword(e.target.value)}}/>
            
            
            
            <button className="btn btn-primary button" onClick={logIn}>Login</button>
            
            <button className="btn btn-danger button">Cancel</button>
            <div class="container signin">
    <p>New User? Register Here <a href="/">Register</a>.</p>
  </div>
        </form>
    );
}
export default UserLogin;
