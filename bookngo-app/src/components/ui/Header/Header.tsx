import { Link } from "react-router-dom";
import LogoutButton from "../../Auth/LogoutButton";

const Header = () => {
    return(
        <header>
            <Link className="logo" to="/Customers">BooknGo</Link>
            <nav>
                <ul className="nav-links">
                    <li><Link to="/customers">Customer List</Link></li>
                    <li><LogoutButton/></li>
                </ul>
            </nav>
        </header>
    );
}

export default Header;