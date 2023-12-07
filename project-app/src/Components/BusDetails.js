import { useState, useEffect } from "react";
import axios from "axios";

function BusDetails() {
  const [busIdError, setBusIdError] = useState("");
  const [searchError, setSearchError] = useState("");
  const [searchResults, setSearchResults] = useState([]);
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
        id: 10
      })
      .then((response) => {
        console.log(response.data);

        // Ensure that response.data is an array before setting it to searchResults
        if (Array.isArray(response.data)) {
          setSearchResults(response.data);
          setSearchPerformed(true);
        } else {
          setSearchError("Invalid response format. Please check the API.");
        }
      })
      .catch((err) => {
        console.error(err);
        setSearchError("Error searching bus. Please try again.");
      });
  };

  return (
    <div>
      <h2>Driver Details</h2>
      {searchPerformed ? (
        <div>
          {searchResults.map((bus, index) => (
            <div key={index} className="bus-details-box">
              <h3>Driver Details</h3>
              <p>
                <strong>Name:</strong> {bus.driverName}
              </p>
              <p>
                <strong>Phone:</strong> {bus.driverPhone}
              </p>
              <p>
                <strong>Rating:</strong> {bus.driverRating}
              </p>
              <p>
                <strong>Age:</strong> {bus.age}
              </p>
            </div>
          ))}
        </div>
      ) : (
        <p>Loading...</p>
      )}
      {searchError && <p>{searchError}</p>}
    </div>
  );
}

export default BusDetails;
