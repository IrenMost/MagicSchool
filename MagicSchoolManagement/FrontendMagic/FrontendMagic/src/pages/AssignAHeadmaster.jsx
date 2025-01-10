

import { Link } from "react-router-dom";
import { useState, useEffect } from "react";

import './AssignAHeadmaster.css';
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
async function fetchAllHousesData() {
    try {
        const response = await fetch(`/api/House/all`, {
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


const AssignAHeadmaster = () => {
    const [loading, setLoading] = useState(true);
    const [allTeachers, setAllTeachers] = useState(null);
    const [allHouses, setAllHouses] = useState(null);
    const [selectedTeacher, setSelectedTeacher] = useState(""); // string, because it is a full name
    

    const [counter, setCounter] = useState(0);
    const [message, setMessage] = useState("");


    const onClickSelect = async (option) => {
        setSelectedTeacher(option)
        console.log("update clicked");
        console.log(option);

    }
    async function onUpdate(houseId, selectedTeacherValue) {
        console.log(houseId);
        console.log(selectedTeacherValue);
        try {
            const response = await fetch(`/api/house/updateHeadmaster`, {
                method: "PATCH",
                credentials: 'include', // to make the server read the jwt cookie
                headers: {
                   "Content-Type": "application/json",

                },
                body: JSON.stringify({ houseId: parseInt(houseId), teacherId: parseInt(selectedTeacherValue) }),
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





    useEffect(() => {
        setLoading(true);
        Promise.all([fetchAllTeacherData(), fetchAllHousesData()])
            .then(([teachers, houses]) => {
                setAllTeachers(teachers.map((teacher) => ({
                    label: teacher.fullname,
                    value: parseInt(teacher.teacherId)
                })));
                console.log("houses:", houses);
                console.log("teachers", teachers)
                setAllHouses(houses);
               
                
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
    if (!allTeachers || allTeachers.length === 0) {
 
        return <div>No teachers found.</div>;
    }
    if (!allHouses || allHouses.length === 0) {
        return <div>No houses found.</div>;
    }
    

    return <div >
        <div className="house-container">
            <table>
                <thead>
                    <tr>
                        <th>HouseName</th>
                        <th>Headmaster</th>
                        <th />
                    </tr>
                </thead>
                <tbody>
                    {allHouses && allHouses.map((house) => (
                        <tr key={house.houseId}>
                            <td>{house.houseName}</td>
                            {/*<td>{house.headmaster}</td>*/}
                            <td>
                                <Select
                                    options={allTeachers}
                                    defaultValue={allTeachers.find(teacher => teacher.label === house.headmaster)}
                                    onChange={(option) => onClickSelect(option)}
                                ></Select>
                            </td>

                            <td>

                                <button className="update" type="button" onClick={() => onUpdate(house.houseId, selectedTeacher.value)}>
                                    Save changes
                                </button>
                           
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

export default AssignAHeadmaster;