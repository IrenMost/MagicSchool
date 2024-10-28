
// itt lesz az összes adat fetch

import { useState, useEffect } from "react";
/*import PointUpdater from "../components/PointUpdater"*/



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


    useEffect(() => {
        fetchAllHouseData().then((data) => {
            setHouseList(data);
            console.log(data);
            setLoading(false);
        });
    }, []);



    if (loading) {
        return <div>Loading...</div>;
    }
    if (!houseList || houseList.length === 0) {
        return <div>No houses found.</div>;
    }

    return <div>
        {houseList && houseList.map((house) => 
        (<div key={house.houseId}>
            <p>id: {house.houseId}</p>
            <h1>{house.houseName}</h1>
            <h2>Current points: {house.points}</h2>

            {/*<PointUpdater houseId={house.houseId} />*/}
        </div>))}

    </div>
               
};

export default HouseList;