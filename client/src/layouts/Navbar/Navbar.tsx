import { Link } from 'react-router-dom'
import "./Navbar.css";

function Navbar() {
  return (
    <nav className="navbar">
      <div>
        <ul className="nav-links">
          <li style={{marginRight: "1rem"}}><Link to="/">Home</Link></li>
          <li style={{marginRight: "1rem"}}><Link to="/Search">Search</Link></li>
          <li style={{marginRight: "1rem"}}><Link to="/Register">Register</Link></li>
          <li style={{marginRight: "1rem"}}><Link to="/Login">Login</Link></li>
          <li style={{marginRight: "1rem"}}><Link to="/Settings">Settings</Link></li>
          <li style={{marginRight: "1rem"}}><Link to="/Author">Author</Link></li>
          <li style={{marginRight: "1rem"}}><Link to="/Members">Members</Link></li>
          <li style={{marginRight: "1rem"}}><Link to="/Payouts">Payouts</Link></li>
          <li style={{marginRight: "1rem"}}><Link to="/Insights">Insights</Link></li>
          <li style={{marginRight: "1rem"}}><Link to="/Checkout">Checkout</Link></li>
        </ul>
      </div>
    </nav>
  )
}

export default Navbar