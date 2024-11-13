
// itt lesz az összes adat fetch
import { Link } from "react-router-dom";
import { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
//import TeacherUpdaterCourse from "../pages/updater/TeacherUpdaterCourse"
//import './HouseList.css';


const TeacherById = () => {
    const [loading, setLoading] = useState(true);
    const [teacher, setTeacher] = useState(null);

    const [counter, setCounter] = useState(0);
    const teacherId = useParams().teacherId


    async function fetchTeacherById() {

        try {


            const response = await fetch(`https://localhost:7135/Teacher/${teacherId}`, {
                method: "GET",
                headers: { "Content-Type": "application/json" }
            });
            if (!response.ok) {
                throw new Error(`Error: ${response.status}`);
            }
            const dataJson = await response.json();
            return dataJson;
        } catch (error) {
            console.error("Error fetching data of houses:", error);
            return null;
        }
    }


    useEffect(() => {
        fetchTeacherById().then((data) => {
            setTeacher(data);
            console.log(data);
            setLoading(false);
        });
    }, [counter]);



    if (loading) {
        return <div>Loading...</div>;
    }


    return <div >
        <div className="teacher-container">

           
        </div>
        <div>
            <Link to={"/"}>
                <button className="back">Back Home</button>
            </Link>
        </div>
    </div>


};

export default TeacherById;