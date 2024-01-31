import React, { useState } from 'react';
import './TicketCardModule.css'; // Import your updated CSS file
import cardImage from './cardImage.jpg';
import upiImage from './upiImage.jpg';
import { useNavigate } from 'react-router-dom';

const TicketCard = () => {
  const [paymentMethod, setPaymentMethod] = useState(null);
  const thisEmail = localStorage.getItem('email');
  const thisBus = localStorage.getItem('thisBus');
  const thisDate = localStorage.getItem('thisDate');
  const thisUserName = localStorage.getItem('thisUserName');
  const [upi, setupi] = useState("");
  const [upiError, setUpiError] = useState("");
  const [cardNumber, setCardNumber] = useState("");
  const [cardNumberError, setCardNumberError] = useState("");
  const [cardHolder, setCardHolder] = useState("");
  const [cardHolderError, setCardHolderError] = useState("");
  const [expiration, setExpiration] = useState("");
  const [expirationError, setExpirationError] = useState("");
  const nav = useNavigate();

  const handlePaymentMethodChange = (method) => {
    setPaymentMethod(method);
  };

  const checkPaymentData = () => {
    if (paymentMethod === 'card') {
      if (cardNumber === "") {
        setCardNumberError("Card Number cannot be Empty!!");
        return false;
      }
      if (expiration === "") {
        setExpirationError("Please Enter this data!!");
        return false;
      }
      if (cardHolder === "") {
        setCardHolderError("Card Holder Name should Not be Empty!!");
        return false;
      }
    } else if (paymentMethod === 'upi') {
      if (upi === "") {
        setUpiError("UPI value cannot be empty!!");
        return false;
      }
    }

    return true;
  };

  const handlePaymentSubmit = (event) => {
    event.preventDefault();
    var data = checkPaymentData();
    if (data === false) {
      alert("Please Check Your Data");
      return;
    }

    // Additional logic for payment submission goes here

    // For example, you can navigate to a new page after successful payment
    alert("Payment Successful!!\n Please Check your Email!!");
    nav('/RedBus');
  };

  return (
    <center>
      <div className="ticketCardContainer">
        <h1>Select Payment Method</h1>
        <div className="paymentMethodContainer">
          <label className="paymentMethodLabel">
            <input
              type="radio"
              name="paymentMethod"
              value="card"
              onChange={() => handlePaymentMethodChange('card')}
              className="paymentMethodInput"
            />
            Card <img src={cardImage} alt="Card" className="paymentIcon" />
          </label>
          <label className="paymentMethodLabel">
            <input
              type="radio"
              name="paymentMethod"
              value="upi"
              onChange={() => handlePaymentMethodChange('upi')}
              className="paymentMethodInput"
            />
            UPI <img src={upiImage} alt="UPI" className="paymentIcon" />
          </label>
        </div>
        {paymentMethod === 'card' && (
          <div>
            <h2>Enter Card Details</h2>
            <div className="cardDetailsContainer">
              <input
                type="text"
                placeholder="Card Number"
                className="textInput cardNumber"
                value={cardNumber}
                onChange={(e) => {
                  setCardNumber(e.target.value);
                }}
              />
              <label className="errorLabel">{cardNumberError}</label>
              <div className="secondLine">
                <input
                  type="text"
                  placeholder="Cardholder Name"
                  className="textInput wideInput"
                  value={cardHolder}
                  onChange={(e) => {
                    setCardHolder(e.target.value);
                  }}
                /><label className="errorLabel">{cardHolderError}</label>
                <input
                  type="text"
                  placeholder="Expiration Date (MM/YYYY)"
                  className="textInput narrowInput" onChange={(e) => {
                    setExpiration(e.target.value);
                  }}
                /><label className="errorLabel">{expirationError}</label>
              </div>
            </div>
          </div>
        )}
        {paymentMethod === 'upi' && (
          <div>
            <h2>Enter UPI ID</h2>
            <input
              type="text"
              placeholder="UPI ID"
              className="textInput"
              value={upi}
              onChange={(e) => {
                setupi(e.target.value);
              }}
            />
            <label className="errorLabel">{upiError}</label>
          </div>
        )}
        <button onClick={handlePaymentSubmit} className="submitButton">
          Submit Payment
        </button>
      </div>
    </center>
  );
};

export default TicketCard;
