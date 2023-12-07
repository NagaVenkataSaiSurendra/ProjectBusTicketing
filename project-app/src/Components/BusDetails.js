import React, { useState, useEffect } from "react";
import axios from "axios";

function BusDetails() {
  const [busIdError, setBusIdError] = useState("");
  const [searchResults, setSearchResults] = useState([]);
  const [searchError, setSearchError] = useState("");
  const [searchPerformed, setSearchPerformed] = useState(false);

  useEffect(() => {
    // This will run when the component is mounted
    fetchData();
  }, []); // The empty dependency array ensures that it runs only once on mount

  const fetchData = () => {
    setBusIdError("");
    setSearchError("");

    axios
      .post("http://localhost:5041/api/Bus/GetBusById", {
        id: 10,
      })
      .then((response) => {
        console.log(response.data);
        setSearchResults(response.data);
        setSearchPerformed(true);
      })
      
      .catch((err) => {
        console.error(err);
        setSearchError("Error searching user. Please try again.");
      });
  };

  return (
    <div>
      <center>
        <h1 className="alert alert-success">
          <center>Driver Details</center>
        </h1>
      </center>
      {searchPerformed && (
        <div>
          <center>
            {Array.isArray(searchResults) && searchResults.length > 0 ? (
              <table className="table">
                <thead>
                  <tr>
                    <th>S.No</th>
                    <th>BusId</th>
                    <th>Type</th>
                    <th>Cost</th>
                    <th>Available Seats</th>
                    <th>Booked Seats</th>
                    <th>Start</th>
                    <th>End</th>
                  </tr>
                </thead>
                <tbody>
                  {searchResults.map((bus, index) => (
                    <tr key={bus.busId}>
                      <td>{index + 1}</td>
                      <td>{bus.id}</td>
                      <td>{bus.type}</td>
                      <td>{bus.cost}</td>
                      <td>{bus.availableSeats}</td>
                      <td>{bus.bookedSeats}</td>
                      <td>{bus.start}</td>
                      <td>{bus.end}</td>
                    </tr>
                  ))}
                </tbody>
              </table>
            ) : (
              <p>No search results found.</p>
            )}
          </center>
        </div>
      )}
    </div>
  );
}

export default BusDetails;
