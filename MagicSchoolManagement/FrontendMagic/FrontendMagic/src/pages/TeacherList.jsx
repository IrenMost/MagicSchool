
// itt lesz az összes adat fetch
import { Link } from "react-router-dom";
import { useState, useEffect } from "react";

import './TeacherList.css';
import Select from 'react-select';



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
async function fetchAllCoursesData() {
    try {
        const response = await fetch(`/api/CourseEnum/all`, {
            method: "GET",
            headers: { "Content-Type": "application/json" }
        });
        if (!response.ok) {
            throw new Error(`Error: ${response.status}`);
        }
        const dataJson = await response.json();
        return dataJson;
    } catch (error) {
        console.error("Error fetching courses:", error);
        return null;
    }
}


const TeacherList = () => {
    const [loading, setLoading] = useState(true);
    const [teacherList, setTeacherList] = useState(null);
    const [allCourses, setAllCourses] = useState([]);
    const [selectedCourse, setSelectedCourse] = useState("");

    const [counter, setCounter] = useState(0);
    const [message, setMessage] = useState("");
   
    

    
    const onClickSelect = async (option) => {
        setSelectedCourse(option)
        console.log("update clicked");
        
    }
    async function onUpdate(teacherId, selectedCourseValue) {
        console.log(teacherId);
        console.log(selectedCourseValue);
        try {
            const response = await fetch(`/api/Teacher/updateTeacherCourse/${teacherId}/${selectedCourseValue}`, {
                method: "PATCH",
                credentials: 'include', // to make the server read the jwt cookie
                //headers: {
                //    "Content-Type": "application/json",

                //},
               /* body: JSON.stringify({ teacherId: parseInt(teacherId), currentCourse: parseInt(selectedCourseValue) })*/
            });
            if (!response.ok) {
                setMessage("save failed");
                throw new Error(`Error: ${response.status}`);
             
            }
            // Update state or handle success here
            if (response.ok) {
                setMessage("Subject saved successfully")
                setCounter((prevCounter) => { return prevCounter + 1 });

                setTimeout(() => {
                    setMessage("");
                }, 3000); 
            }
            
            

        } catch (error) {
            console.error("Error updating points:", error);
        }

    }


    //const onUpdateLevel = async (teacherId) => {
    //    console.log("update clicked");
    //    navigate(`/teacherUpdaterLevel/${teacherId}`);
    //}

    
    useEffect(() => {
        setLoading(true);
        Promise.all([fetchAllTeacherData(), fetchAllCoursesData()])
            .then(([teachers, courses]) => {
                setTeacherList(teachers);
                setAllCourses(courses.map((course, index) => ({
                    label: course, // to be able to use key value pairs of select
                    value: index, 
                })));
                //console.log("Teachers:", teachers);
                //console.log("Courses:", courses);
            })
            .catch((error) => {
                console.error("Error fetching data:", error);
            })
            .finally(() => {
               
                setLoading(false);
            });
    }, [counter]);



    if (loading) {
        return <div>Loading...</div>;
    }
    if (!teacherList || teacherList.length === 0) {
        return <div>No teachers found.</div>;
    }
    if (!allCourses || allCourses.length === 0) {
        return <div>No courses found.</div>;
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
                            <td>
                                <Select
                                    options={allCourses}
                                    defaultValue={allCourses.find(course => course.label === teacher.currentCourse)}
                                    onChange={(option) => onClickSelect(option)}
                                ></Select>
                            </td>

                            <td>
                               
                                <button className="update" type="button" onClick={() => onUpdate(teacher.teacherId, selectedCourse.value)}>
                                    Save selected subject
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
        {message && <p className="message">{message}</p>}
    </div>


};

export default TeacherList;