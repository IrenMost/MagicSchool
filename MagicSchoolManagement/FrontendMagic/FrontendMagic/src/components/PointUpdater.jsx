//import { Outlet } from "react-router-dom";

//const PointUpdater = (houseList) => {
//    const [updatedPoints, setUpdatedPoints] = useState(false);
//    const [pointsToAddOrTakeaway, setPointsToAddOrTakeaway] = useState(null);
//    const [isAdd, setIsAdd] = useState(true)


//    return (
//        <div className="container">

//            <div>
//                <div className="HouseData">

//                    {houseList && houseList.map((house) => (
//                        <container key={house.houseId}>
//                            <h2>{house.houseId}</h2>
//                            <h1>{house.name}</h1>
//                            <h2>{house.headmaster}</h2>
//                            <h2>{house.points}</h2>

//                            <form className="updatePoints" onSubmit={updatedPoints}>
//                                <div className="control">
//                                    <label htmlFor="points">Points:</label>
//                                    <input
//                                        type="number"
//                                        value={pointsToAddOrTakeaway}
//                                        onChange={(e) => setPointsToAddOrTakeaway(e.target.value)}
//                                        name="pointsToAddOrTakeaway"
//                                        id={house.houseId}
//                                    />
//                                </div>

//                                <div className="buttons">
//                                    <button type="submit"
//                                        value="add">Add Points </button>

//                                </div>


//                                <div className="buttons">
//                                    <button type="submit"
//                                        value="takeaway">Take Away Points</button>

//                                </div>
//                            </form>

//                        </container>
//                    ))}



//                </div>
//            </div>

//        </div>
//    );
//};

//export default PointUpdater;