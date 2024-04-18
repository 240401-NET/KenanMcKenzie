
const QuizzesTable = () => {
  return (
    <div className="overflow-x-auto">
  <table className="table">
    {/* head */}
    <thead>
      <tr>
        <th></th>
        <th>Name</th>
        <th>Description</th>
        <th>Tags</th>
        <th>Questions</th>
      </tr>
    </thead>
    <tbody>
      {/* row 1 */}
      <tr>
        <th>1</th>
        <td>c#</td>
        <td>covers week 1</td>
        <td>tag arr mapped</td>
        <td>25</td>
      </tr>
      {/* row 2 */}
      <tr className="hover">
        <th>2</th>
        <td>Hart Hagerty</td>
        <td>Desktop Support Technician</td>
        <td>Purple</td>
        <td>Purple</td>
      </tr>
      {/* row 3 */}
      <tr>
        <th>3</th>
        <td>Brice Swyre</td>
        <td>Tax Accountant</td>
        <td>Red</td>
      </tr>
    </tbody>
  </table>
</div>
  )
}

export default QuizzesTable