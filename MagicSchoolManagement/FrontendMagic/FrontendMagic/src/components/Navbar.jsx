import { Link } from "react-router-dom";
import './Navbar.css'

export default function Navbar() {
    return (
        <nav className="nav-bar">
            
            <Link to={"/teacher/houseList"}>
                <button>PointList</button>
            </Link>
            <Link to={"/director/teacherList"}>
                <button>Teacher`s courses</button>
            </Link>
            <Link to={"/director/assignAHeadmaster"}>
                <button>Assign a Headmaster</button>
            </Link>
            <Link to={"/login" }>
                <button>Login</button>
            </Link>
            
            
         
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