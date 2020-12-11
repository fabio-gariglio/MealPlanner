import React, { useState } from "react";
import { Form, Button } from "react-bootstrap";
import { useHistory } from "react-router-dom";
import axios from "axios";

export function RecipeCreator() {

  let history = useHistory();
  const [name, setName] = useState("");
  const [instructionList, setInstructionList] = useState("");
  const [ingredientList, setIngredientList] = useState("");
  const [servings, setServings] = useState(1);
  const [preparation, setPreparation] = useState(10);

  function handleClick() {
    axios.post("/api/recipes/import",
        {
          name: name,
          ingredientList: ingredientList,
          instructionList: instructionList,
          servings: parseInt(servings),
          preparation: parseInt(preparation)
        })
      .then(response => {
        history.push(`/recipes/${response.data.id}`);
      })
      .catch(error =>
        console.error(error)
      );
  };

  return (
    <Form>
      <Form.Group controlId="recipeForm.name">
        <Form.Label>Recipe Name</Form.Label>
        <Form.Control
          type="text"
          placeholder="Recipe Name"
          value={name}
          onChange={e => setName(e.target.value)}
        />
      </Form.Group>

      <Form.Group controlId="recipeForm.instructions">
        <Form.Label>Instructions</Form.Label>
        <Form.Control
          as="textarea"
          placeholder="Instructions"
          rows={6}
          value={instructionList}
          onChange={e => setInstructionList(e.target.value)}
        />
      </Form.Group>

      <Form.Group controlId="recipeForm.ingredients">
        <Form.Label>Ingredients</Form.Label>
        <Form.Control
          as="textarea"
          placeholder="Ingredients"
          rows={6}
          value={ingredientList}
          onChange={e => setIngredientList(e.target.value)}
        />
      </Form.Group>

      <Form.Group controlId="recipeForm.servings">
        <Form.Label>Servings</Form.Label>
        <Form.Control
          as="select"
          value={servings}
          onChange={e => setServings(e.target.value)}>
          <option>1</option>
          <option>2</option>
          <option>3</option>
          <option>4</option>
          <option>5</option>
          <option>6</option>
          <option>8</option>
        </Form.Control>
      </Form.Group>

      <Form.Group controlId="recipeForm.preparation">
        <Form.Label>Preparation (in minutes)</Form.Label>
        <Form.Control
          type="number"
          value={preparation}
          onChange={e => setPreparation(e.target.value)}
        />
      </Form.Group>

      <Button variant="primary" onClick={handleClick}>
        Submit
      </Button>
    </Form>
  );

};