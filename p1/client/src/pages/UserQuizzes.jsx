import { useEffect, useState } from "react";
import Header from "../components/Header";
import QuizzesTable from "../components/QuizzesTable";
import axios from "axios";

const UserQuizzes = () => {
  const [authenticated, setAuthenticated] = useState(false);
  const [userData, setUserData] = useState({});
  useEffect(() => {
    axios
      .get("/api/user/verify", { withCredentials: true })
      .then((res) => {
        if (res.status === 200) {
          setAuthenticated(true);
        }
        return res.data;
      })
      .then((data) => {
        localStorage.setItem("user", data.user.email);
        localStorage.setItem("userInfo", JSON.stringify(data.user));
        setUserData(data.user);
      })
      .catch((err) => {
        console.log("Could not authenticate: ", err);
        localStorage.removeItem("user");
        localStorage.removeItem("userInfo");
      });
  }, [authenticated]);
  console.log("Authenticated ", authenticated);
  return (
    <div className="bg-neutral-content max-w-full h-screen">
      {authenticated ? (
        <Header title={`${userData.userName} Quizzes`} />
      ) : (
        <Header title="User Quizzes" />
      )}
      <div className="py-16 mx-24 border border-zinc-200 bg-zinc-500 rounded-lg shadow-xl">
        <QuizzesTable userId={userData.id} />
      </div>
    </div>
  );
};

export default UserQuizzes;
