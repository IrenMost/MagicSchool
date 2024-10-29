
// itt lesz az összes adat fetch

import { useState, useEffect } from "react";
import PointUpdater from "../components/PointUpdater"



async function fetchAllHouseData() {
    try {
        const response = await fetch(`https://localhost:7135/House/all`, {
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



const HouseList = () => {
    const [loading, setLoading] = useState(true);
    const [houseList, setHouseList] = useState(null);

    const [updatedHouse, setUpdatedHouse] = useState(false);
    



    useEffect(() => {
        fetchAllHouseData().then((data) => {
            setHouseList(data);
            console.log(data);
            setLoading(false);
        });
    }, [updatedHouse]);



    if (loading) {
        return <div>Loading...</div>;
    }
    if (!houseList || houseList.length === 0) {
        return <div>No houses found.</div>;
    }
    const houseColors = ["red-gold", "yellow-black", "blue-bronze", "green-silver"];

    return <div className="house-container">
        {houseList && houseList.map((house, index) => 
        (<div key={house.houseId} className={`house-box ${houseColors[index]}`}>
           
            <h1>{house.houseName}</h1>
            <h2>Current points: {house.points}</h2>

            <PointUpdater
                houseId={house.houseId}
                setUpdatedHouse={setUpdatedHouse }
                />
        </div>))}

    </div>
               
};

export default HouseList;