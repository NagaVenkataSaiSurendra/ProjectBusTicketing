import { useState } from "react";
function Users(){
    const [userList,setUserList]=useState([]);
    var getUsers = ()=>{
        fetch('http://localhost:5041/api/Customer/GetAllUsers',{
            method:'GET',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            }
        }).then(
            async (data)=>{
                var myData = await data.json();
                await console.log(myData);
                await setUserList(myData);
            }
        ).catch((e)=>{
            console.log(e)
        })
    }
    var checkUsers = userList.length>0?true:false;
return(
    <div>
        <h1 className="alert alert-success">Users</h1>
        <button className="btn btn-success" onClick={getUsers}>Get All Users</button>
        <hr/>
        {checkUsers? 
            <div >
                {userList.map((user)=>
                    <div key={user.Name} className="alert alert-primary">
                        UserName : {user.userName}
                        <br/>
                        Email : {user.email}
                        <br/>
                        Phone : {user.phone}
                        <br/>
                        City: {user.city}
                        <br/>
                        Pincode : {user.pincode}
                        <br/>
                        Role :{user.role}
                </div>)}
            </div>
            :
            <div>No Users available yet</div>
            }
    </div>
);
}
export default Users; 
 