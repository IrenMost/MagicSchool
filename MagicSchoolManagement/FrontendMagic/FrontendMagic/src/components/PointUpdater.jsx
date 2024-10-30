
import './PointUpdater.css';
import { useState, } from "react";
import PropTypes from "prop-types"; 

const PointUpdater = ({
    houseId,
   
    setUpdatedHouse 
}) => {
    const [pointsToAddOrTakeaway, setPointsToAddOrTakeaway] = useState(null);
    

    const handleSubmitPlus = async () => {

        try {
            const response = await fetch(`https://localhost:7135/House/updatePoints/${houseId}`, {
                method: "PATCH",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify({ houseId: houseId, points: parseInt(pointsToAddOrTakeaway), isAdd: true }),
            });
            if (!response.ok) {
                throw new Error(`Error: ${response.status}`);
            }
            // Update state or handle success here
            setUpdatedHouse(true);
        } catch (error) {
            console.error("Error updating points:", error);
        }
    };

    const handleSubmitMinus = async () => {

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
            setUpdatedHouse(true);
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
   
    setUpdatedHouse: PropTypes.func.isRequired
};

export default PointUpdater;