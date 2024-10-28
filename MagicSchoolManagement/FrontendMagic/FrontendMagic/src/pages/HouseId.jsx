
// itt lesz az összes adat fetch

import { useState, useEffect } from "react";
/*import PointUpdater from "../components/PointUpdater"*/



async function fetchAHouseData() {
    try {
        const response = await fetch(`/api/House/1`, {
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



const HouseId = () => {
    const [loading, setLoading] = useState(true);
    const [house1, setHouse1] = useState(null);


    useEffect(() => {
        fetchAHouseData().then((data) => {
            setHouse1(data);
            console.log(data);
            setLoading(false);
        });
    }, []);



    if (loading) {
        return <div>Loading...</div>;
    }
   

    return <div>

    
            <p>id: {house1.houseId}</p>
            <h1>{house1.houseName}</h1>
            <h2>Current points: {house1.points}</h2>

            {/*<PointUpdater houseId={house.houseId} />*/}
   

    </div>

};

export default HouseId;