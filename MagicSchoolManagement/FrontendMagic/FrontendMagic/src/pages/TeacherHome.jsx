//import "./HomePage.css";
import Navbar from "../components/Navbar"
import { Link } from "react-router-dom";


export default function TeacherHome() {



    return (
        <div className="teacherHome">
            <Navbar />
            <img src="wand.png" alt="logo" className="header-logo" />
            <header className="header">
                <h1 className="header-title">
                    Hello!


                </h1>
    
            </header>
            <Link to={"/teacher/houseList"}>
                <button>Point competiton</button>
            </Link>
            <button> see my students by grade</button>
            <button> go on a vacation to Albania</button>
        </div>
    );
}