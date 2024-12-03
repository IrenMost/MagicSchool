
// itt lesz az összes adat fetch
import { Link } from "react-router-dom";
import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import './TeacherList.css';



async function fetchAllTeacherData() {
    try {
        const response = await fetch(`/api/Teacher/all`, {
            method: "GET",
            headers: { "Content-Type": "application/json" }
        });
        if (!response.ok) {
            throw new Error(`Error: ${response.status}`);
        }
        const dataJson = await response.json();
        return dataJson;
    } catch (error) {
        console.error("Error fetching data of teachers:", error);
        return null;
    }
}



const HouseList = () => {
    const [loading, setLoading] = useState(true);
    const [teacherList, setTeacherList] = useState(null);
   
    const navigate = useNavigate();

    
    const onUpdate = async (teacherId) => {
        console.log("update clicked");
        navigate(`/director/TeacherUpdater/${teacherId}`);
    }

    //const onUpdateLevel = async (teacherId) => {
    //    console.log("update clicked");
    //    navigate(`/teacherUpdaterLevel/${teacherId}`);
    //}



    useEffect(() => {
        fetchAllTeacherData().then((data) => {
            setTeacherList(data);
            console.log(data);
            setLoading(false);
        });
    }, []);



    if (loading) {
        return <div>Loading...</div>;
    }
    if (!teacherList || teacherList.length === 0) {
        return <div>No teachers found.</div>;
    }
    

    return <div >
        <div className="teacher-container">
            <table>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Status</th>
                        <th>Subject taught</th>
                        <th />
                    </tr>
                </thead>
                <tbody>
                    {teacherList && teacherList.map((teacher) => (
                        <tr key={teacher.teacherId}>
                            <td>{teacher.fullname}</td>
                            <td>{teacher.level}</td>
                            <td>{teacher.currentCourse}</td>

                            <td>
                               
                                <button className="update" type="button" onClick={() => onUpdate(teacher.typeId)}>
                                    Update 
                                </button>
                                {/*<button type="button" onClick={() => onUpdateLevel(teacher.typeId)}>*/}
                                {/*    Update level*/}
                                {/*</button>*/}
                            </td>

                        </tr>
                    ))}

                </tbody>
            </table>


        </div>
        <div>
            <Link to={"/"}>
                <button className="back">Back Home</button>
            </Link>
        </div>
    </div>


};

export default HouseList;