import { config } from "../../wailsjs/go/models";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";

interface ServerSelectProps {
  value: config.LoginServer | null;
  options: config.LoginServer[];
}

const ServerSelect = (props: ServerSelectProps) => {
  const { value, options } = props;
  return (
    <Select
      value={value?.Name}
      // TODO: remove disabled in the future
      disabled
    >
      <SelectTrigger className="w-[180px]">
        <SelectValue placeholder="Please select a server" />
      </SelectTrigger>
      <SelectContent>
        {options.map((option) => (
          <SelectItem key={option.Name} value={option.Name}>
            {option.Name}
          </SelectItem>
        ))}
      </SelectContent>
    </Select>
  );
};

export default ServerSelect;
