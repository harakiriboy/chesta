import React, { useState } from 'react'

function RegisterPage() {
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    console.log(`Submitted: ${firstName} ${lastName}, ${email}, ${password}`);
    // Add your registration logic here
  };

  const containerStyle = {
    display: "flex",
    justifyContent: "center",
    alignItems: "center",
    height: "100vh",
  };

  const buttonStyle = {
    margin: "1rem 0 0 0",
    padding: "0.5rem",
    width: "100%",
    backgroundColor: "#007bff",
    color: "#fff",
    border: "none",
    borderRadius: "4px",
    cursor: "pointer",
  };

  return (
    <div style={containerStyle}>
      <form onSubmit={handleSubmit} style={{display: "flex",
    flexDirection: "column",
    alignItems: "center",
    padding: "2rem",
    border: "1px solid #ccc",
    borderRadius: "4px",}}>
        <h2>Registration Form</h2>
        <input
          type="text"
          placeholder="First Name"
          value={firstName}
          onChange={(e) => setFirstName(e.target.value)}
          style={{margin: "0.5rem",
          padding: "0.5rem",
          width: "100%",
          border: "1px solid #ccc",
          borderRadius: "4px",
          boxSizing: "border-box",}}
        />
        <input
          type="text"
          placeholder="Last Name"
          value={lastName}
          onChange={(e) => setLastName(e.target.value)}
          style={{margin: "0.5rem",
          padding: "0.5rem",
          width: "100%",
          border: "1px solid #ccc",
          borderRadius: "4px",
          boxSizing: "border-box",}}
        />
        <input
          type="email"
          placeholder="Email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          style={{margin: "0.5rem",
          padding: "0.5rem",
          width: "100%",
          border: "1px solid #ccc",
          borderRadius: "4px",
          boxSizing: "border-box",}}
        />
        <input
          type="password"
          placeholder="Password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
          style={{margin: "0.5rem",
          padding: "0.5rem",
          width: "100%",
          border: "1px solid #ccc",
          borderRadius: "4px",
          boxSizing: "border-box",}}
        />
        <button type="submit" style={buttonStyle}>
          Register
        </button>
      </form>
    </div>
  );
};

export default RegisterPage