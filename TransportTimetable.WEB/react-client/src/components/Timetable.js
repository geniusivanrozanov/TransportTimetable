import React from 'react';
import {Card, Container} from "react-bootstrap";

const Timetable = ({timetable}) => {
  timetable = timetable.filter(tt => tt.dayOfWeek == 1)
    .sort((a, b) => a.hours === b.hours ? a.minutes - b.minutes : a.hours - b.hours)
  console.log(timetable)
  return (
    <Container className={"gap-5"}>
      {timetable.map(tt => <Card className={"d-inline-flex p-2"}>{`${tt.hours}:${tt.minutes}`}</Card>)}
    </Container>
  );
};

export default Timetable;