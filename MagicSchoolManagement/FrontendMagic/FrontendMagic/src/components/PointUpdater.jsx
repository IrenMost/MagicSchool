
import './PointUpdater.css';
import { useState, } from "react";
import PropTypes from "prop-types"; 

const PointUpdater = ({
    houseId,
   
    setCounter 
}) => {
    const [pointsToAddOrTakeaway, setPointsToAddOrTakeaway] = useState("");
    
    const token = document.cookie // assuming the token is stored as a cookie
        .split('; ')
        .find(row => row.startsWith('Authorization='))
        ?.split('=')[1];


    const handleSubmitPlus = async () => {

        if (pointsToAddOrTakeaway < 0) {
            alert("Don't try to cheat with negative numbers!"); 
            setPointsToAddOrTakeaway("");
            return;
        }
        try {
            const response = await fetch(`https://localhost:7135/House/updatePoints/${houseId}`, {
                method: "PATCH",
                credentials: 'include', // to make the server read the jwt cookie
                headers: {
                    "Content-Type": "application/json",
                    "Authorization": `Bearer ${token}`, // Pass the token here
                },
                body: JSON.stringify({ houseId: houseId, points: parseInt(pointsToAddOrTakeaway), isAdd: true }),
            });
            if (!response.ok) {
                throw new Error(`Error: ${response.status}`);
            }
            // Update state or handle success here
            setCounter((prevCounter) => { return prevCounter + 1 });
            setPointsToAddOrTakeaway("");
           
        } catch (error) {
            console.error("Error updating points:", error);
        }
    };

    const handleSubmitMinus = async () => {

        if (pointsToAddOrTakeaway < 0) {
            alert("Don't try to cheat with negative numbers!");
            setPointsToAddOrTakeaway("");
            return;
        }
        try {
            const response = await fetch(`https://localhost:7135/House/updatePoints/${houseId}`, {
                method: "PATCH",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify({ houseId: houseId, points: parseInt(pointsToAddOrTakeaway), isAdd: false }),
            });
            if (!response.ok) {
                throw new Error(`Error: ${response.status}`);
            }
            // Update state or handle success here
            setCounter((prevCounter) => { return prevCounter + 1 });
            setPointsToAddOrTakeaway("");
        } catch (error) {
            console.error("Error updating points:", error);
        }
    };

    return (
       <div className="point-container">
           {/* Input field, positioned above the button group */}
            <input
                type="number"
                value={pointsToAddOrTakeaway}
                onChange={(e) => { setPointsToAddOrTakeaway(e.target.value); console.log(e.target.value);  console.log(e.target.id); }}
                id={houseId}
            />

            {/* Group for buttons, kept side-by-side */}
            <div className="button-input-group">
                <button
                    type="submit"
                    name="submit_add"
                    value="submit_a"
                    onClick={() => handleSubmitPlus()}
                >
                    Add Points
                </button>

                <button
                    type="submit"
                    name="submit_takeaway"
                    value="submit_t"
                    onClick={() =>  handleSubmitMinus() }
                        
                >
                    Take Away Points
                </button>
                </div>
           
        </div>
    );
};

PointUpdater.propTypes = {
    houseId: PropTypes.string.isRequired,
   
    setCounter: PropTypes.func.isRequired
};

export default PointUpdater;