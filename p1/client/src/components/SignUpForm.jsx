import { useState } from "react";
import { useNavigate, Link } from "react-router-dom";
// import { signUp } from "../api/userService";
import logo from "../assets/quizlogo.png";
import axios from "axios";
const SignUpForm = () => {
  //email, username, password
  const [Email, setEmail] = useState("");
  const [PasswordHash, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  const [Name, setName] = useState("");
  const [UserName, setUserName] = useState("");

  const navigate = useNavigate();

  const handleSignup = async (e) => {
    e.preventDefault();
    const dataToSend = {
      Email,
      PasswordHash,
      Name,
      UserName,
    };
    console.log(dataToSend);
    try {
      const response = await axios.post(
        "api/user/register",
        JSON.stringify(dataToSend),
        {
          withCredentials: true,
          headers: {
            "Content-Type": "application/json",
            Accept: "application/json",
          },
        }
      );
      const data = await response.data;

      if (response.ok) {
        console.log(data);
        console;
        localStorage.setItem("user", JSON.stringify(dataToSend.Email));
        navigate("/signin");
      }
    } catch (error) {
      console.log("Error", error);
    }
  };

  const inputClass =
    "block w-full rounded-md border-0 pl-2 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600";
  const labelClass =
    "block text-md font-semibold font-medium leading-6 text-gray-900";
  return (
    <div className="flex h-screen flex-col justify-center px-6 py-12 lg:px-8 bg-neutral-content font-mono">
      <div className="sm:mx-auto sm:w-full sm:max-w-sm">
        <Link to="/">
          <img className="mx-auto h-32 w-auto" src={logo} alt="logo" />
        </Link>
        <h2 className="mt-10 text-center text-4xl font-bold  leading-9 tracking-tight text-neutral">
          Create an account
        </h2>
      </div>

      <div className="mt-10 sm:mx-auto sm:w-full sm:max-w-sm">
        <form className="space-y-6" onSubmit={handleSignup}>
          <div>
            <label className={labelClass}>Name</label>
            <div className="mt-2">
              <input
                type="text"
                value={Name}
                required
                className={inputClass}
                onChange={(e) => setName(e.target.value)}
              />
            </div>
          </div>
          <div>
            <label className={labelClass}>Username</label>
            <div className="mt-2">
              <input
                type="text"
                value={UserName}
                required
                className={inputClass}
                onChange={(e) => setUserName(e.target.value)}
              />
            </div>
          </div>

          <div>
            <label htmlFor="email" className={labelClass}>
              Email
            </label>
            <div className="mt-2">
              <input
                id="email"
                type="email"
                autoComplete="email"
                value={Email}
                required
                className={inputClass}
                onChange={(e) => setEmail(e.target.value)}
              />
            </div>
          </div>

          <div>
            <div className="flex items-center justify-between">
              <label htmlFor="password" className={labelClass}>
                Password
              </label>
            </div>
            <div className="mt-2">
              <input
                id="password"
                type="password"
                value={PasswordHash}
                required
                className={inputClass}
                onChange={(e) => setPassword(e.target.value)}
              />
            </div>
          </div>
          <div>
            <div className="flex items-center justify-between">
              <label htmlFor="password" className={labelClass}>
                Confirm Password
              </label>
            </div>
            <div className="mt-2">
              <input
                id="passwordconfirm"
                type="password"
                value={confirmPassword}
                required
                className={inputClass}
                onChange={(e) => setConfirmPassword(e.target.value)}
              />
            </div>
          </div>

          <div className="flex justify-center">
            <button
              type="submit"
              className="btn bg-zinc-600 text-amber-400 border-amber-400 w-48 text-lg hover:bg-amber-400 hover:text-zinc-600 hover:scale-110 hover:border-zinc-600"
            >
              Sign Up
            </button>
          </div>
        </form>

        <p className="mt-10 text-center text-md text-gray-500">
          Already a member?
          <Link
            to="/signin"
            className="font-semibold leading-6 text-neutral hover:text-amber-400"
          >
            {" "}
            Sign In
          </Link>
        </p>
      </div>
    </div>
  );
};

export default SignUpForm;
