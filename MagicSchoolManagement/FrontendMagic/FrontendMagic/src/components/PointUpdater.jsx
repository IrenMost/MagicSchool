import { Outlet } from "react-router-dom";
import './PointUpdater.css';
import { useState, } from "react";
import PropTypes from "prop-types"; // Import prop-types

const PointUpdater = ({
    houseId,
    updatedHouse,
    setUpdatedHouse 
}) => {
    const [pointsToAddOrTakeaway, setPointsToAddOrTakeaway] = useState(null);
    const [isAdd, setIsAdd] = useState(true)

    const handleSubmit = async () => {

        console.log("clicked");
        console.log(isAdd);
       
        try {
            const response = await fetch(`https://localhost:7135/House/updatePoints/${houseId}`, {
                method: "PATCH",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify({ houseId: houseId, points: pointsToAddOrTakeaway, isAdd: isAdd }),
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
                    onClick={() => { setIsAdd(true); handleSubmit();  }}
                >
                    Add Points
                </button>

                <button
                    type="submit"
                    name="submit_takeaway"
                    value="submit_t"
                    onClick={() => { setIsAdd(false); handleSubmit(); }
                        }
                >
                    Take Away Points
                </button>
                </div>
           
        </div>
    );
};

//PointUpdater.propTypes = {
//    houseId: PropTypes.string.isRequired,
//    updatedHouse: PropTypes.bool.isRequired,
//    setUpdatedHouse: PropTypes.func.isRequired
//};

export default PointUpdater;