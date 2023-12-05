import { useState, useEffect } from 'react';
import './App.css';
import BusSeatSelection from './Components/BusSeatSelection';
import SearchBus from './Components/SearchBus';
import UpdateUser from './Components/UpdateUser';
import Seat from './Components/Seat';
import Menu from './Components/Menu';
import RegisterUser from './Components/RegisterUser';
import UserLogin from './Components/UserLogin';
import { BrowserRouter, Route, Routes ,Switch} from 'react-router-dom';
import DisplaySeat from './Components/DisplaySeat';
import Buses from './Components/Buses';
import Protected from './Protected';
import UserHistory from './Components/UserHistory';
import Users from './Components/Users';
import BookingList from './Components/BookingList';
import RedBus from './Components/RedBus';
import Logout from './Components/Logout';

function App() {
  return (
    <BrowserRouter>
      <Menu />
      <Routes>
        <Route path='/' element={<RegisterUser />} />
        <Route path="/UserLogin" element={<UserLogin />} />
        <Route path="Buses" element={<Protected><Buses /></Protected>} />
        <Route path="BusSeatSelection" element={<Protected><BusSeatSelection /></Protected>} />
        <Route path="UpdateUser" element={<UpdateUser />} />
        <Route path="UserHistory" element={<UserHistory />} />
        <Route path="Users" element={<Protected><Users/></Protected>} />
        <Route path="BookingList" element={<Protected><BookingList /></Protected>} />
        <Route path="RedBus" element={<RedBus />} />
        <Route path="Logout" element={<Logout/>}/>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
