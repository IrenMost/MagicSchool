
// itt lesz az összes adat fetch
import { Link } from "react-router-dom";
import { useState, useEffect } from "react";
import PointUpdater from "../components/PointUpdater"
import './HouseList.css';



async function fetchAllHouseData() {
    try {
        const response = await fetch(`/api/House/all`, {
            method: "GET",
            
            headers: { "Content-Type": "application/json" },
            
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

    const [counter, setCounter] = useState(0);
    



    useEffect(() => {
        fetchAllHouseData().then((data) => {
            setHouseList(data);
            console.log(data);
          
            setLoading(false);
        });
    }, [counter]);



    if (loading) {
        return <div>Loading...</div>;
    }
    if (!houseList || houseList.length === 0) {
        return <div>No houses found.</div>;
    }
    const houseColors = ["red-gold", "yellow-black", "blue-bronze", "green-silver"];

    return <div >
        <div className="house-container">
        
        {houseList && houseList.map((house, index) => (
            <div key={house.houseId} className={`house-box ${houseColors[index]}`}>

                {/* Oval background for house name */}
                <div className="house-name-oval">
                    <h1>{house.houseName}</h1>
                </div>

                <h2>Current points: {house.points}</h2>

                <PointUpdater
                    houseId={house.houseId}
                   
                    setCounter={setCounter}
                />
            </div>
        ))}
        </div>
        <div>
            <Link to={"/"}>
                <button className="back">Back Home</button>
            </Link>
        </div> 
    </div>
    
               
};

export default HouseList;