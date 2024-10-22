import { Link } from "react-router-dom";

const Navbar = () =>{
    return(
        <nav className="navbar">
            <h1>
                <link></link>
            </h1>
            <div className="links">
                <li className="menu-item">
                    <Link to="/Bookings" className="btn">See bookings</Link>
                </li>
                <li>
                    <Link to="/Availabilities" className="btn">See Availabilities</Link>
                </li>
                <li>
                    <Link to="/Resources" className="btn">See Resources</Link>
                </li>
                <li>
                    <Link to="/Login" className="btn">See Login</Link>
                </li>
            </div>
        </nav>
    );
}

export default Navbar;