import { useState } from "react";
import { IoIosAddCircleOutline } from "react-icons/io";
const CreateQuizForm = () => {
  const [quizTitle, setQuizTitle] = useState("");
  const [tag,setTag] = useState([])
  const tagArray = [];

  const handleAddTag = () => {
    tagArray.push(tag);
    console.log("tag: " + tag)
    console.log("tagArray: " + tagArray.length)
  }
  return (
    <div className="flex flex-col justify-center gap-y-2">
      <label className="form-control w-full max-w-xs">
        <div className="label">
          <span className="label-text">Title</span>
        </div>
        <input type="text" placeholder="Type here" value={quizTitle} onChange={(e) => setQuizTitle(e.target.value)} className="input input-bordered w-full max-w-xs" />
      </label>
      {/*Question*/}
      <p>{quizTitle}</p>

      {/*Don't display until the end*/}
      <label className="form-control w-full max-w-xs">
        <div className="label">
          <span className="label-text">Add tags</span>
          <span className="label-text-alt">(Up to 3)</span>
        </div>
        <div className="flex items-center gap-2">
        <input type="text" placeholder="Type here" value={tag} onChange={(e) => setTag(e.target.value)} className="input input-bordered w-full max-w-xs" />
        <button onClick={handleAddTag}>
        <IoIosAddCircleOutline className="text-2xl"/>
        </button>
        </div>
      </label>
      <button className="btn btn-neutral">Add Questions</button>
    </div>
  )
}

export default CreateQuizForm