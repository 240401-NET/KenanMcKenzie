import { useState } from "react";
import logo from "../assets/quizlogo.png";
import { useNavigate, Link } from "react-router-dom";
import { loginUser } from "../api/userService";

const SignInForm = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const navigate = useNavigate();

  const handleLogin = async (e) => {
    e.preventDefault();
    try {
      const response = await loginUser(email, password);
      console.log(response);
      navigate("/user");
    } catch (error) {
      console.error(error);
    }
  };

  const inputClass =
    "block w-full rounded-md border-0 pl-2 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600";
  const labelClass = "block text-md font-medium leading-6 text-gray-900";
  return (
    <div className="flex h-screen flex-col  px-6 pt-32 lg:px-8 bg-neutral-content font-mono">
      <div className="sm:mx-auto sm:w-full sm:max-w-md ">
        <Link to="/" className="py-6">
          <img className="mx-auto h-32 w-auto" src={logo} alt="logo" />
        </Link>
        <h2 className="mt-10 pb-8 text-center text-4xl font-bold  leading-9 tracking-tight text-neutral">
          Sign in to your account
        </h2>
      </div>
      <div className="mt-10 sm:mx-auto sm:w-full sm:max-w-sm">
        <form className="space-y-6" onSubmit={handleLogin}>
          <div>
            <label htmlFor="email" className={labelClass}>
              Email
            </label>
            <div className="mt-2">
              <input
                id="email"
                name="email"
                type="email"
                autoComplete="email"
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
                name="password"
                type="password"
                autoComplete="current-password"
                required
                className={inputClass}
                onChange={(e) => setPassword(e.target.value)}
              />
            </div>
          </div>

          <div className="flex justify-center">
            <button
              type="submit"
              className="btn bg-zinc-600 text-amber-400 border-amber-400 w-48 text-lg hover:bg-amber-400 hover:text-zinc-600 hover:scale-110 hover:border-zinc-600"
            >
              Sign In
            </button>
          </div>
        </form>

        <p className="mt-10 text-center text-md text-gray-500">
          Not a member?
          <Link
            to="/signup"
            className="font-semibold leading-6 text-neutral hover:text-amber-400"
          >
            {" "}
            Create an account
          </Link>
        </p>
      </div>
    </div>
  );
};

export default SignInForm;
