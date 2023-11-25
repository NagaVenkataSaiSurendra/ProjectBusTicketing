import { useState } from "react";
import axios from "axios";
import './UserLogin.css'

function UserLogin(){
    const roles =["User","Admin"];
    const [username,setUsername] = useState("");
    const [password,setPassword] = useState("");
    const [role,setRole] = useState("");
    var [usernameError,setUsernameError]=useState("");
    var checkUSerData = ()=>{
        if(username=='')
        {
            setUsernameError("Username cannot be empty");
            return false;
        }
           
        if(password=='')
            return false;
        if(role=='Select Role')
            return false;
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
        axios.post("http://localhost:5041/api/Customer/login",{
            username: username,
            role:	role,
            password:password
    })
    .then((userData)=>{
        console.log(userData)
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
            <label >{usernameError}</label>

            <label className="form-control">Password</label>
            <input type="password" className="form-control" value={password}
                    onChange={(e)=>{setPassword(e.target.value)}}/>
            
            
            <select className="form-select" onChange={(e)=>{setRole(e.target.value)}}>
                <option value="select">Select Role</option>
                {roles.map((r)=>
                    <option value={r} key={r}>{r}</option>
                )}
            </select>
            <br/>
            <button className="btn btn-primary button" onClick={logIn}>Login</button>
            
            <button className="btn btn-danger button">Cancel</button>
        </form>
    );
}
export default UserLogin;