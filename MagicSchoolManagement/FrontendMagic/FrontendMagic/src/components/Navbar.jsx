import { Link } from "react-router-dom";
import './Navbar.css'

export default function Navbar() {
    return (
        <nav className="nav-bar">
            
            <Link to={"/teacher/houseList"}>
                <button>HouseList</button>
            </Link>
            <Link to={"/director/teacherList"}>
                <button>Teacher`s list</button>
            </Link>
            <Link to={"/login" }>
                <button>Login</button>
            </Link>
            <button>More</button>
            {/*<Link to={"/register"}>*/}
            {/*    <button>Register</button>*/}
            {/*</Link>*/}
 
            <Link to={"/logout"}>
                <button>Logout</button>
            </Link>
            {/*<Link to={"/test"}>*/}
            {/*    <button>Test</button>*/}
            {/*</Link>*/}
            
        </nav>
    );
}